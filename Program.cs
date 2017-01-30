using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XslTool
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				Console.WriteLine("XslTool <input.xml> <transform.xslt> [<output>]");
				return;
			}
			string uri = args[0];
			string stylesheetUri = args[1];
			string filename = args.Length == 3 ? args[2] : null;
			try
			{
				XPathDocument input = new XPathDocument(uri);
				XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
				xslCompiledTransform.Load(stylesheetUri);
				XmlTextWriter results = filename != null ? new XmlTextWriter(filename, null) : new XmlTextWriter(Console.Out);
				xslCompiledTransform.Transform(input, null, results);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}
