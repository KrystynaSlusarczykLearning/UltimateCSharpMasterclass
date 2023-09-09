var passwordGenerator = new PasswordGenerator(
    new RandomWrapper());

for(int i = 0; i < 10; i++)
{
    Console.WriteLine(passwordGenerator.Generate(5, 10, false));
}

Console.ReadKey();
