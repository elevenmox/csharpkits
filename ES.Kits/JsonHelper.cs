using Newtonsoft.Json;
using System;
using System.IO;

namespace ES.Kits
{
    /// <summary>
    /// JSON处理类
    /// </summary>
    public class JsonHelper
    {
        /*官网教程： https://www.newtonsoft.com/json/help/html/Samples.htm
         * 
         * 问题1：统一时间格式
         * 解决：https://www.cnblogs.com/litian/p/3870975.html
         * 
         */

        /// <summary>
        /// 将json字符串转换为实体类对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>实体类对象</returns>
        public static T Parse<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                NLogHelper.Error("反序列化异常", ex);
                return default(T);
            }
        }
        /// <returns></returns>
        /// <summary>
        /// 将类对象转化为json字符串
        /// </summary>
        /// <param name="value">类对象</param>
        /// <param name="dateFormat">日期格式，默认年月日时分秒</param>
        /// <returns>json字符串</returns>
        public static string Stringify(object value, string dateFormat = "yyyy-MM-dd HH:mm:ss")
        {
            try
            {
                return JsonConvert.SerializeObject(value,
                new JsonSerializerSettings { DateFormatString = dateFormat });
            }
            catch (Exception ex)
            {
                NLogHelper.Error("序列化异常", ex);
                return null;
            }
        }
        /// <summary>
        /// 序列化并写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="value">类对象</param>
        /// <param name="dateFormat">日期格式，默认年月日时分秒</param>
        public static bool StringifyToFile(string filePath, object value, string dateFormat = "yyyy-MM-dd HH:mm:ss")
        {
            try
            {
                using (StreamWriter swriter = File.CreateText(filePath))
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings { DateFormatString = dateFormat };
                    JsonSerializer serializer = JsonSerializer.Create(setting);
                    serializer.Serialize(swriter, value);
                }
                return true;
            }
            catch (Exception ex)
            {
                NLogHelper.Error("写入json数据失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 反序列化文件中的json字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <param name="dateFormat">日期格式，默认年月日时分秒</param>
        public static T ParseFromFile<T>(string filePath, string dateFormat = "yyyy-MM-dd HH:mm:ss")
        {
            try
            {
                using (StreamReader sreader = File.OpenText(filePath))
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings { DateFormatString = dateFormat };
                    JsonSerializer serializer = JsonSerializer.Create(setting);
                    return (T)serializer.Deserialize(sreader, typeof(T));
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("写入json数据失败", ex);
                return default(T);
            }
        }
    }
}
