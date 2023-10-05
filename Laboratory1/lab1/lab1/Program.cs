using System.IO;

public class Lab1
{
    static void Main()
    {
        string csvFilePath = "/Users/georgijguzuk/RiderProjects/laboratories_CSharp_ZUT/Laboratory1/lab1/lab1/input.csv";
        string htmlFilePath = "/Users/georgijguzuk/RiderProjects/laboratories_CSharp_ZUT/Laboratory1/lab1/lab1/output.html";
        convertCsvToHtml(csvFilePath, htmlFilePath);
        
    }
    
    static void convertCsvToHtml(string csvFilePath, string htmlFilePath)
    {
        string[] lines = File.ReadAllLines(csvFilePath);
        using (StreamWriter HTMLFile = new StreamWriter(htmlFilePath)) {
            HTMLFile.WriteLine("<html>" +
                               "<head>" +
                               "<style>\ntable {\n  font-family: arial, sans-serif;\n  border-collapse: collapse;\n  width: 100%;\n}\n\ntd, th {\n  border: 1px solid #dddddd;\n  text-align: left;\n  padding: 8px;\n}\n\ntr:nth-child(even) {\n  background-color: #dddddd;\n}" +
                               "</style>" +
                               "<title>CSV to HTML</title>" +
                               "</head>" + 
                               "<body>" +
                               "<table border=\"1\">" +
                               "<tr>");
            string[] headers = lines[0].Split(",");
            foreach (var header in headers)
            {
                HTMLFile.WriteLine("<th>" + header + "</th>");
            }
            HTMLFile.WriteLine("</tr>");

            for(int i = 1; i < lines.Length; i++)
            {
                HTMLFile.WriteLine("<tr>");
                string[] parts = lines[i].Split(",");
                foreach (var part in parts)
                {
                    HTMLFile.WriteLine("<td>" + part + "</td>");
                }
                HTMLFile.WriteLine("</tr>");
            }
            
            HTMLFile.WriteLine(
                "</table>" +
                "</body>" +
                "</html>"
            );
        }
    }
}