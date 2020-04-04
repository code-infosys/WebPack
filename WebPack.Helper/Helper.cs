using System;

namespace WebPack.Helper
{
    public class Helper
    {
        public string GetMessage(string inputMessage)
        {
            return "Your message is: " + inputMessage;
        }

        public int GetSum(int value1,int value2)
        {
            return (value1 + value2);
        }
    }
}
