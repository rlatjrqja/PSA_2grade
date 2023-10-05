
Console.Write("경로를 지정하세요 : ");
String dir = Console.ReadLine();

//string dir = Environment.CurrentDirectory;
//week05.exe의 위치(실행위치)를 가져온다???

String input;
String output;

Console.Write("파일명 : ");
String filename = Console.ReadLine();

StreamWriter sw = new StreamWriter(dir + "\\"+ filename,true);
Console.WriteLine("\n========입력모드를 종료하려면 exit를 입력하세요========");

while(true)
{
    input = Console.ReadLine();
    if (input == "exit") break;

    sw.WriteLine(input);
}
sw.Close();

Console.WriteLine($"{dir + "\\" + filename}에 작성되었습니다.\n");

StreamReader sr = new StreamReader(dir + "\\" + filename);
while (true)
{
    output = sr.ReadLine();
    Console.WriteLine(output);
    if(output == null) break;
}
sr.Close();