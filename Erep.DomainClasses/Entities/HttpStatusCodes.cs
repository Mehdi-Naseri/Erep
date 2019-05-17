using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erep.DomainClasses.Entities
{
    class HttpStatusCode
    {
        public List<HttpStatusCodesViewModel> HttpStatusCodes = new List<HttpStatusCodesViewModel>
        {
            //1xx: Information
            new HttpStatusCodesViewModel(100,"Continue","The requester has asked the server to switch protocols"),
            new HttpStatusCodesViewModel(101,"Switching Protocols","The requester has asked the server to switch protocols"),
            new HttpStatusCodesViewModel(103,"Checkpoint","Used in the resumable requests proposal to resume aborted PUT or POST requests"),
            //2xx: Successful
            new HttpStatusCodesViewModel(200,"OK","The request is OK (this is the standard response for successful HTTP requests)"),
            new HttpStatusCodesViewModel(201,"Created","The request has been fulfilled, and a new resource is created"),
            new HttpStatusCodesViewModel(202,"Accepted","The request has been accepted for processing, but the processing has not been completed"),
            new HttpStatusCodesViewModel(203,"Non-Authoritative Information","The request has been successfully processed, but is returning information that may be from another source"),
            new HttpStatusCodesViewModel(204,"No Content","The request has been successfully processed, but is not returning any content"),
            new HttpStatusCodesViewModel(205,"Reset Content","The request has been successfully processed, but is not returning any	content, and requires that the requester reset the document view"),
            new HttpStatusCodesViewModel(206,"Partial Content","The server is delivering only part of the resource due to a range header sent by the client"),
            //3xx: Redirection
            new HttpStatusCodesViewModel(300,"Multiple Choices","A link list. The user can select a link and go to that location. Maximum five addresses"),
            new HttpStatusCodesViewModel(301,"Moved Permanently","The requested page has moved to a new URL"),
            new HttpStatusCodesViewModel(302,"Found","The requested page has moved temporarily to a new URL"),
            new HttpStatusCodesViewModel(303,"See Other","The requested page can be found under a different URL"),
            new HttpStatusCodesViewModel(304,"Not Modified","Indicates the requested page has not been modified since last requested"),
            new HttpStatusCodesViewModel(306,"Switch Proxy","---No longer used---"),
            new HttpStatusCodesViewModel(307,"Temporary Redirect","The requested page has moved temporarily to a new URL"),
            new HttpStatusCodesViewModel(308,"Resume Incomplete","Used in the resumable requests proposal to resume aborted PUT or POST requests"),
            //4xx: Client Error
            new HttpStatusCodesViewModel(400,"Bad Request","The request cannot be fulfilled due to bad syntax"),
            new HttpStatusCodesViewModel(401,"Unauthorized","The request was a legal request, but the server is refusing to respond	to it. For use when authentication is possible but has failed or not yet been provided"),
            new HttpStatusCodesViewModel(402,"Payment Required","---Reserved for future use---"),
            new HttpStatusCodesViewModel(403,"Forbidden","The request was a legal request, but the server is refusing to respond to it"),
            new HttpStatusCodesViewModel(404,"Not Found","The requested page could not be found but may be available again in the future"),
            new HttpStatusCodesViewModel(405,"Method Not Allowed","A request was made of a page using a request method not supported by that page"),
            new HttpStatusCodesViewModel(406,"Not Acceptable","The server can only generate a response that is not accepted by the client"),
            new HttpStatusCodesViewModel(407,"Proxy Authentication Required","The client must first authenticate itself with the proxy"),
            new HttpStatusCodesViewModel(408,"Request Timeout","The server timed out waiting for the request"),
            new HttpStatusCodesViewModel(409,"Conflict","The request could not be completed because of a conflict in the request"),
            new HttpStatusCodesViewModel(410,"Gone","The requested page is no longer available"),
            new HttpStatusCodesViewModel(411,"Length Required","The &quot;Content-Length&quot; is not defined. The server will not accept the request without it"),
            new HttpStatusCodesViewModel(412,"Precondition Failed","The precondition given in the request evaluated to false by the server"),
            new HttpStatusCodesViewModel(413,"Request Entity Too Large","The server will not accept the request, because the request entity is too large"),
            new HttpStatusCodesViewModel(414,"Request-URI Too Long","The server will not accept the request, because the URL is too long. Occurs when you convert a POST request to a GET request with a long query information"),
            new HttpStatusCodesViewModel(415,"Unsupported Media Type","The server will not accept the request, because the media type is not supported"),
            new HttpStatusCodesViewModel(416,"Requested Range Not Satisfiable","The client has asked for a portion of the file, but the server cannot supply that portion"),
            new HttpStatusCodesViewModel(417,"Expectation Failed","The server cannot meet the requirements of the Expect request-header	field"),
            //5xx: Server Error
            new HttpStatusCodesViewModel(500,"Internal Server Error","A generic error message, given when no more specific message is suitable"),
            new HttpStatusCodesViewModel(501,"Not Implemented","The server either does not recognize the request method, or it lacks the ability to fulfill the request"),
            new HttpStatusCodesViewModel(502,"Bad Gateway","The server was acting as a gateway or proxy and received an invalid response from the upstream server"),
            new HttpStatusCodesViewModel(503,"Service Unavailable","The server is currently unavailable (overloaded or down)"),
            new HttpStatusCodesViewModel(504,"Gateway Timeout","The server was acting as a gateway or proxy and did not receive a timely response from the upstream server"),
            new HttpStatusCodesViewModel(505,"HTTP Version Not Supported","The server does not support the HTTP protocol version used in the request"),
            new HttpStatusCodesViewModel(511,"Network Authentication Required","The client needs to authenticate to gain network access")
        };
        public class HttpStatusCodesViewModel
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public string Description { get; set; }

            public HttpStatusCodesViewModel(int Code1, string Message1, string Description1)
            {
                Code = Code1;
                Message = Message1;
                Description = Description1;
            }
        }
    }


}
