
Console.Write("경로를 지정하세요 : ");
String dir = Console.ReadLine();

DirectoryInfo dirInfo = new DirectoryInfo(dir);
if(dirInfo.Exists==false)
{
    Console.WriteLine("존재하지 않는 경로입니다. 입력한 경로를 생성합니다.");
    dirInfo.Create();
}//인스턴스 매서드. 객체 지향적 방법

//Directory.CreateDirectory(dir);
//정적 메서드

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
Console.WriteLine($"{filename}내용");
while (true)
{
    output = sr.ReadLine();
    Console.WriteLine(output);
    if(output == null) break;
}
sr.Close();