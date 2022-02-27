using static System.Console;

long mem = GC.GetTotalMemory(true);
WriteLine($"{mem} bytes.\n");

#region Change a value type by ref
int ten = 10;
WriteLine($"Initial value type:\n\t{ten}");

ChangeValueTypeByRef(ref ten);
WriteLine($"Backed value type:\n\t{ten}");
#endregion Change a value type by ref

#region Change a reference string type by ref
string message = "DONALD TRUMP";
WriteLine($"Initial string type:\n\t{message}");

ChangeStringByRef(ref message);
WriteLine($"Backed string type::\n\t{message}");
#endregion Change a reference string type by ref

#region Change a record struct type by ref
Product product = new("Threes", 333);
WriteLine($"Initial record struct type:\n\tName: {product.Name}\n\tId: {product.NewId}");

ChangeTypeByRef(ref product);
WriteLine($"Backed record struct type:\n\tName: {product.Name}\n\tId: {product.NewId}");
#endregion Change a record struct type by ref

mem = GC.GetTotalMemory(true) - mem;
WriteLine($"\n{mem} bytes.");

// value |= 0b_01000000; value + (1 * (2^6));
void ChangeValueTypeByRef(ref int value) => value |= (1 << 6);

void ChangeStringByRef(ref string msg) => msg = msg.ToLowerInvariant();

void ChangeTypeByRef(ref Product itemRef) => itemRef = new Product("Ones", 111);

internal record struct Product(string Name, int NewId)
{
    internal string Name { get; set; } = Name;
    internal int NewId { get; set; } = NewId;
}
