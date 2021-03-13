namespace YDManagement.Helpers
{
    public class JResultHelper
    {
        public string Key { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }
        public object Extend { get; set; }

        public string GetKey()
        {
            return Key;
        }

        public void SetKey(string key)
        {
            Key = key;
        }

        public string GetStatus()
        {
            return Status;
        }
        public void SetMessage(string message)
        {
            Extend = new JMessage(message);
        }

        public void SetStatusSuccess()
        {
            Status = "SUCCESS";
        }
        public void SetStatusFailed()
        {
            Status = "FAILED";
        }

        public object GetData()
        {
            return Data;
        }

        public void SetData(object data)
        {
            Data = data;
        }

        public object GetExt()
        {
            return Extend;
        }

        public void SetExt(object ext)
        {
            Extend = ext;
        }
    }

    public class JMessage
    {
        public string Msg { get; set; }

        public JMessage(string message)
        {
            Msg = message;
        }
    }

    public class JPaging
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}