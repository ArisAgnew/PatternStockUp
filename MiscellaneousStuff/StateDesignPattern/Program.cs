using StateDesignPattern;
using StateDesignPattern.States;

StateComponent stateHandler = new(10, 10, new InitialState());
stateHandler.DoLike();

Console.WriteLine(stateHandler.Likes);
Console.WriteLine(stateHandler.Dislikes);

/*char byte1 = (char)0x80; // 128
char byte2 = (char)0x10; // 16
int specimen = 0xFFFF;

uint pattern = 0xA1B2C3D4;
Console.WriteLine($"Pattern: {pattern}");

ushort value1 = (ushort)((byte2 << 8) | (byte1 & 0xFF));
ushort value2 = (ushort)((byte2 << 8) | byte1);

Console.WriteLine("value1 = {0:G} {1:X}", value1, value1);
Console.WriteLine("value2 = {0:G} {1:X}", value2, value2);

Console.WriteLine((byte2 << 8) | (byte1 & 0xFF));
Console.WriteLine((byte2 << 8) | byte1);*/
