
//test case for composite pattern
//create root directory first
using DesignPatterns.CompositePatterns;

clsDirectory root = new clsDirectory("root", 0);
clsDirectory music = new clsDirectory("Musics", 0);
clsDirectory picture = new clsDirectory("Pictures", 0);
//lets create some files now
clsFile mp3File1 = new clsFile("love.mp3", 3);
clsFile mp3File2 = new clsFile("peace.mp3", 4);
//
clsFile pic1 = new clsFile("mypic.jpg", 3);
//
Console.WriteLine($"Current root directory size is {root.FileSize()}");
root.AddFiles(music);
root.AddFiles(picture);
music.AddFiles(mp3File1);
music.AddFiles(mp3File2);
picture.AddFiles(pic1);
//
Console.WriteLine($"After adding other directories and files the root directory size is {root.FileSize()}");
root.Display();
