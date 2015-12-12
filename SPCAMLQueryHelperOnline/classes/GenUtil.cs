using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Security;

namespace SPCAMLQueryHelperOnline
{
    public class GenUtil
    {

        /// <summary>
        /// </summary>
        public static string WrapWSQuery(object query)
        {
            var strQuery = SafeTrim(query);

            if (!strQuery.StartsWith("<query>", StringComparison.InvariantCultureIgnoreCase))
            {
                strQuery = string.Concat("<Query>", strQuery, "</Query>");
            }

            return strQuery;
        }

        /// <summary>
        /// </summary>
        public static void LogIt(System.Windows.Forms.TextBox txtStatus, string s)
        {
            txtStatus.Text = string.Format("[{0}] ", DateTime.Now.ToLongTimeString()) + s + Environment.NewLine + Environment.NewLine + txtStatus.Text;
            txtStatus.Refresh();
        }

        /// <summary>
        /// </summary>
        public static string CombineUrls(string part1, string part2)
        {
            part1 = SafeTrim(part1).TrimEnd(new char[] { '/' });
            part2 = SafeTrim(part2).TrimStart(new char[] { '/' });

            return part1 + "/" + part2;
        }

        /// <summary>
        /// </summary>
        public static string GetXElemAttrAsString(XElement e, string attr)
        {
            string ret = "";

            try
            {
                if (e != null)
                    if (e.HasAttributes)
                        if (e.Attributes().Any(x => x.Name == attr))
                            ret = SafeTrim(e.Attribute(attr).Value);
            }
            catch 
            {
                ret = "";
            }

            return ret;
        }

        /// <summary>
        /// </summary>
        public static string FormatXml(string inputXml)
        {
            XmlDocument document = new XmlDocument();
            document.Load(new StringReader(inputXml));

            StringBuilder builder = new StringBuilder();
            using (XmlTextWriter writer = new XmlTextWriter(new StringWriter(builder)))
            {
                writer.Formatting = Formatting.Indented;
                document.Save(writer);
            }

            return builder.ToString();
        }

        /// <summary>
        /// </summary>
        public static bool IsNull(object x)
        {
            if ((x == null)
                || (Convert.IsDBNull(x))
                || x.ToString().Trim().Length == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// </summary>
        public static string SafeTrim(object x)
        {
            if (IsNull(x))
                return "";
            else
                return x.ToString().Trim();
        }

        /// <summary>
        /// If not valid returns 0.
        /// </summary>
        public static int SafeToNum(object o)
        {
            if (IsNull(o))
                return 0;
            else
            {
                if (IsInt(o))
                    return int.Parse(o.ToString());
                else
                    return 0;
            }
        }

        /// <summary>
        /// If not valid returns 0.
        /// </summary>
        public static double SafeToDouble(object o)
        {
            if (IsNull(o))
                return -1;
            else
            {
                double test;
                if (!double.TryParse(o.ToString(), out test))
                    return -1;
                else
                    return test;
            }
        }

        /// <summary>
        /// If not valid returns false.
        /// </summary>
        public static bool SafeToBool(object o)
        {
            if (IsNull(o))
                return false;
            else
            {
                bool result;
                if (!bool.TryParse(o.ToString(), out result))
                {
                    if (o.ToString() == "1" || o.ToString().Trim().ToLower() == "yes" || o.ToString().Trim().ToLower() == "true")
                        return true;
                    else
                        return false;
                }
                else
                    return result;
            }
        }

        /// <summary>
        /// If not valid returns 01/01/1900 12:00:00 AM.
        /// </summary>
        public static DateTime SafeToDateTime(object o)
        {
            if (IsNull(o))
                return DateTime.Parse("01/01/1900 12:00:00 AM");
            else
            {
                DateTime dummy;

                if (IsInt(o))
                    return new DateTime(Convert.ToInt64(o)); // use ticks
                else
                {
                    if (DateTime.TryParse(o.ToString(), out dummy))
                        return dummy;
                    else
                        return DateTime.Parse("01/01/1900 12:00:00 AM"); ;
                }
            }
        }

        /// <summary>
        /// </summary>
        public static bool IsInt(object o)
        {
            if (IsNull(o))
                return false;

            Int64 Dummy = 0;
            return Int64.TryParse(o.ToString(), out Dummy);
        }

        /// <summary>
        /// </summary>
        public static bool IsDouble(object o)
        {
            if (IsNull(o))
                return false;

            Double Dummy = 0;
            return Double.TryParse(o.ToString(), out Dummy);
        }

        /// <summary>
        /// </summary>
        public static bool IsGUID(object o)
        {
            try
            {
                Guid g = new Guid(o.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        public static string NormalizeEol(string s)
        {
            return Regex.Replace(Regex.Replace(SafeTrim(s), @"(\n)|(\r)|(\n\r)|(\r\n)", "\r\n"), @"(\r\n){2,}", "\r\n");
        }

        /// <summary>
        /// </summary>
        public static string RemoveWhiteSpace(object s)
        {
            return Regex.Replace(GenUtil.SafeTrim(s), "[\\t\\r\\n]", "");
        }

        /// <summary>
        /// </summary>
        public static string SafeToUpper(object o)
        {
            if (IsNull(o))
                return "";
            else
                return SafeTrim(o).ToUpper();
        }

    }
}
