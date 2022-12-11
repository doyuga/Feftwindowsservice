using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Xml; 

namespace FEFTWnSvc.utilies
{
    /// <summary>
    /// http://code.msdn.microsoft.com/windowsdesktop/WCF-REST-Message-Inspector-c4b6790b#content
    /// </summary>
    public class IncomingMessageLogger : IDispatchMessageInspector, IEndpointBehavior 
    {
        private static Logger log = new Logger();
        
        static int messageLogFileIndex = 0;

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Uri requestUri = null;
            try
            {

                StringBuilder sb = new StringBuilder();
                requestUri = request.Headers.To;

                string strbank = requestUri.AbsolutePath;
                //strbank = strbank.Substring(12, 1);
                HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
                sb.AppendFormat("{0} {1}" + Environment.NewLine, httpReq.Method, requestUri);
                foreach (var header in httpReq.Headers.AllKeys)
                {
                    sb.AppendFormat("{0} {1}" + Environment.NewLine, header, httpReq.Headers[header]);
                }

                if (strbank == "2")
                {
                    log.logingmode = "EQUITY";
                }
                else
                {
                    log.logingmode = "KCB";
                }
                //}


                if (!request.IsEmpty)
                {
                    sb.AppendLine(this.MessageToString(ref request));
                }
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, sb.ToString());
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.INFO, sb.ToString());
                }

                log.logingmode = null;
            }
            catch (Exception ex)
            {
                //log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.ERROR, ex.Message);
                }

            }
            return requestUri;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("Response to request to {0}:" + Environment.NewLine, (Uri)correlationState);
                HttpResponseMessageProperty httpResp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                sb.AppendFormat("{0} {1}" + Environment.NewLine, (int)httpResp.StatusCode, httpResp.StatusCode);



                if (!reply.IsEmpty)
                {
                    sb.AppendLine(this.MessageToString(ref reply));
                }

               // log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, sb.ToString());
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, sb.ToString());
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.INFO, sb.ToString());
                }
            }
            catch (Exception ex) 
            {
                //log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.ERROR, ex.Message);
                }
            }
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            try
            {
                if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
                {
                    WebBodyFormatMessageProperty bodyFormat;
                    bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                    format = bodyFormat.Format;
                }
            }
            catch (Exception ex) 
            { 
                //log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message); 
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.ERROR, ex.Message);
                }
            }
            return format;
        }

        private string MessageToString(ref Message message)
        {
            string messageBody = "";
            try
            {
                WebContentFormat messageFormat = this.GetMessageContentFormat(message);
                MemoryStream ms = new MemoryStream();
                XmlDictionaryWriter writer = null;
                switch (messageFormat)
                {
                    case WebContentFormat.Default:
                    case WebContentFormat.Xml:
                        writer = XmlDictionaryWriter.CreateTextWriter(ms);
                        break;
                    case WebContentFormat.Json:
                        writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                        break;
                    case WebContentFormat.Raw:
                        // special case for raw, easier implemented separately 
                        return this.ReadRawBody(ref message);
                }

                message.WriteMessage(writer);
                writer.Flush();
                messageBody = Encoding.UTF8.GetString(ms.ToArray());

                // Here would be a good place to change the message body, if so desired. 

                // now that the message was read, it needs to be recreated. 
                ms.Position = 0;

                // if the message body was modified, needs to reencode it, as show below 
                // ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody)); 

                XmlDictionaryReader reader;
                if (messageFormat == WebContentFormat.Json)
                {
                    reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max);
                }
                else
                {
                    reader = XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
                }

                Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
                newMessage.Properties.CopyProperties(message.Properties);
                message = newMessage;

                //log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, string.Format("String Message: {0}", message));
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, string.Format("String Message: {0}", message));
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.INFO, string.Format("String Message: {0}", message));
                }
            }
            catch (Exception ex)
            { 
               // log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message); 
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.ERROR, ex.Message);
                }
            }


            return messageBody;
        }

        private string ReadRawBody(ref Message message)
        {
            string messageBody = "";
            try
            {
                XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
                bodyReader.ReadStartElement("Binary");
                byte[] bodyBytes = bodyReader.ReadContentAsBase64();
                messageBody = Encoding.UTF8.GetString(bodyBytes);

                // Now to recreate the message 
                MemoryStream ms = new MemoryStream();
                XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
                writer.WriteStartElement("Binary");
                writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
                writer.WriteEndElement();
                writer.Flush();
                ms.Position = 0;
                XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
                Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
                newMessage.Properties.CopyProperties(message.Properties);
                message = newMessage;

                //log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, message);
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.INFO, message);
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.INFO, message);
                }
            }
            catch (Exception ex) {

                //log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                if (log.logingmode == "EQUITY")
                {

                    log.LogMsg(LogModes.FILE_RAW, LogLevel.ERROR, ex.Message);
                }
                else
                {
                    log.LogMsg(LogModes.FILE_RAW_KCB, LogLevel.ERROR, ex.Message);
                }
            }
            
            return messageBody;
        } 
    }
}
