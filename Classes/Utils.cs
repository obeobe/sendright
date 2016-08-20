
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace SendRight {
	public static partial class Utils {
		public static bool isInDebugger() {
			return System.Diagnostics.Debugger.IsAttached;
		}

		////////////////////////////
		////////////////////////////
		//
		// extension functions
		//
		////////////////////////////
		////////////////////////////

		public static bool isNumeric(this string s) {
			int dummy;
			return int.TryParse(s, out dummy);
		}

		public static int toInt(this string s) {
			int result = -1;
			if (s == null) return result;
			if (s.Trim() == "") return result;
			if (!int.TryParse(s, out result)) return 0;
			return result;
		}

		public static string getXml(this XDocument xDoc) {
			if (xDoc == null) {
				return null;
			}

			MemoryStream stream = new MemoryStream();
			XmlTextWriter tx = new XmlTextWriter(stream, new UTF8Encoding());
			tx.Formatting = Formatting.Indented;
			tx.Indentation = 1;
			tx.IndentChar = '\t';

			xDoc.Save(tx);
			tx.Flush();

			stream.Position = 0;
			StreamReader reader = new StreamReader(stream);
			string xml = reader.ReadToEnd();

			return xml;
		}

		public static string getXml(this XElement xElement) {
			string TOPTOPTOP = "toptoptop";
			XDocument xDoc = XDocument.Parse($"<{TOPTOPTOP }/>");
			xDoc.Element(TOPTOPTOP).Add(xElement);
			//return xDoc.getXml().Replace($"<toptoptop>", "").Replace("</toptoptop>", "");
			string xml = xDoc.getXml();
			xml = xml.Substring(TOPTOPTOP.Length + 2, xml.Length - (TOPTOPTOP.Length * 2 + 5));
			return xml;
		}

		public static bool toBool(this string s) {
			if (s == null) return false;
			s = s.ToLower().Trim();
			if (s == "0") {
				return false;
			}
			else if (s == "false") {
				return false;
			}
			else if (s == "no") {
				return false;
			}
			else if (s == "") {
				return false;
			}
			return true;
		}

		public static float toFloat(this string s) {
			float result = -1;
			if (s == null) return result;
			float.TryParse(s, out result);
			return result;
		}

		public static DateTime? toDateTime(this string s) {
			if (s.isEmpty()) return null;
			DateTime dt;
			if (!DateTime.TryParse(s, out dt)) return null;
			dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
			return dt;
		}

		public static string getAttributeValue(this XElement x, string name) {
			XAttribute xAttribute = x.Attributes(name).FirstOrDefault();
			if (xAttribute == null) return null;
			return xAttribute.Value;
		}

		public static T coalesce<T>(this T t, T alternative) {
			if (t == null) {
				return alternative;
			}
			return t;
		}

		public static bool isEmpty<T>(this T t) {
			if (t == null) return true;
			string s = t.ToString();
			if (s == "" || s == "0") return true;
			return false;
		}

		public static T coalesceEmpty<T>(this T t, T alternative) {
			if (t.isEmpty()) {
				return alternative;
			}
			return t;
		}

		public static bool? toBoolOrNull(this string s) {
			if (s == null || s == "") return null;
			return s.toBool();
		}

		public static string boolOrNullToString(this bool? b) {
			if (b == null) return "";
			return b.ToString();
		}

		public static string[] toLines(this string s) {
			return s.coalesce("").Replace("\r\n", "\n").Split("\n".ToCharArray());
		}

		public static string toLine(this IEnumerable<string> s) {
			return string.Join("\r\n", s);
		}

		public static string toStringOrNull(this object o) {
			if (o == null) {
				return null;
			}

			if (o is string) {
				return (string)o;
			}

			if (o is System.DBNull) {
				return null;
			}

			return o.ToString();
		}

		public static void pointerWait() {
			System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
		}

		public static void pointerDefault() {
			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

		public static string toBase64(this string s) {
			if (s == null) return null;
			byte[] toEncodeAsBytes = System.Text.Encoding.Unicode.GetBytes(s);
			return toEncodeAsBytes.toBase64();
		}

		public static string toBase64(this byte[] toEncodeAsBytes) {
			string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
			return returnValue;
		}

		public static string fromBase64(this string s) {
			byte[] encodedDataAsBytes = System.Convert.FromBase64String(s);
			string returnValue = System.Text.Encoding.Unicode.GetString(encodedDataAsBytes);
			return returnValue;
		}

		public static string md5(this string s) {
			if (s == null) return null;

			Byte[] originalBytes;
			Byte[] encodedBytes;
			System.Security.Cryptography.MD5 md5;

			md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			originalBytes = ASCIIEncoding.Default.GetBytes(s);
			encodedBytes = md5.ComputeHash(originalBytes);

			return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
		}

		public static XElement clone(this XElement x) {
			XElement wrapper = new XElement("wrapper", x);
			XElement clone = wrapper.Elements().FirstOrDefault();
			return clone;
		}

		public static void runSoon(int waitMS, Action action) {
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = waitMS;
			timer.Tick += (s, e) => {
				timer.Enabled = false;
				action();
			};
			timer.Enabled = true;
		}

		public static XAttribute addOrGetAttribute(this XElement x, string name) {
			return x.addOrGetAttribute(name, "");
		}

		public static XAttribute addOrGetAttribute(this XElement x, string name, string defaultValue) {
			if (x.Attribute(name) == null) x.Add(new XAttribute(name, defaultValue));
			return x.Attribute(name);
		}

		public static string[] delimitedToArray(this string commaDelimited, char[] arrDelimiters = null) {
			if (arrDelimiters == null) arrDelimiters = ",".ToCharArray();
			return commaDelimited.Split(",".ToCharArray()).Select(s => s.Trim()).Where(s => !s.isEmpty()).ToArray();
		}

		public static IEnumerable<string> toLower(this IEnumerable<string> ie) {
			return ie.Select(item => item.ToLower());
		}
	}
}
