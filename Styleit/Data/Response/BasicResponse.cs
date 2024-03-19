namespace Styleit.Data.Response
{
    public class BasicResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static BasicResponse ofSuccess(object data)
        {
            BasicResponse response = new BasicResponse();
            response.status = 0;
            response.message = "success";
            response.data = data;
            return response;
        }
        public static BasicResponse ofSuccess(String messsage, Object data)
        {
            BasicResponse response = new BasicResponse();
            response.status = 0;
            response.message = messsage;
            response.data = data;
            return response;
        }
        public static BasicResponse ofFailure(string message)
        {
            BasicResponse response = new BasicResponse();
            response.status = 99;
            response.message = message;
            return response;
        }
    }
}
