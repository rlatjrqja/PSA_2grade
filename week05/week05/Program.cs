String path = "C:\\MyFiles\\yuhan\\PSA\\PSA_2grade\\week05\\";

Console.Write("파일명 : ");
String fileName = Console.ReadLine();

String TargetFile = "ReadTestFile.txt";
StreamReader sr1 = new StreamReader(path + TargetFile);

while (sr1.EndOfStream == false)
{
    string s = sr1.Read().ToString();
    Console.Write(s);
}

StreamWriter sw1 = new StreamWriter(path + fileName);
sw1.WriteLine(sr1);
sw1.Close();