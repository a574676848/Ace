using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Token
{
    public static partial class TokenHelper
    {
        /// <summary>
        /// 生成一个新的凭据
        /// </summary>
        /// <returns></returns>
        private static string NewToken()
        {
            //凭据长度96
            char[] guid = Guid.NewGuid().ToString("N").ToArray(); //32位
            string nonceStr = Noncestr(64); //64位

            Random rd = new Random();
            for (int i = 0; i < guid.Length; i++)
            {
                if (rd.Next(0, 2) == 0)
                {
                    guid[i] = char.ToLower(guid[i]);
                }
            }

            string tempGuid = new string(guid);
            return nonceStr.Substring(0, 20) + tempGuid.Substring(0, 16) + nonceStr.Substring(20, 20) + tempGuid.Substring(16) + nonceStr.Substring(40) + TimeStamp();
        }

        /// <summary>
        /// 生成一个新的刷新令牌
        /// </summary>
        /// <returns></returns>
        public static string NewRefreshToken()
        {
            return NewToken();
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        private static string TimeStamp()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        }

        /// <summary>
        /// 生成随机字符串(包含数字、大小写字母)
        /// </summary>
        /// <param name="length">随机字符串长度(默认16位,最小5位)</param>
        /// <returns></returns>
        private static string Noncestr(int length = 16)
        {
            length = length < 5 ? 5 : length;
            char[] str = new char[length];
            Random rd = new Random();
            int number = 0;

            for (int i = 0; i < length; i++)
            {
                number = rd.Next(0, 72);
                if (number < 26)
                {
                    str[i] = (char)(number + 65); //数字A-Z编码在65-90
                }
                else if (number < 36)
                {
                    str[i] = (char)(number + 22); //数字0-9编码在48-57
                }
                else if (number < 62)
                {
                    str[i] = (char)(number + 61); //数字a-z编码在97-122
                }
                else
                {
                    str[i] = (char)(number - 14); //数字0-9编码在48-57
                }
            }

            return new string(str);
        }
    }
}
