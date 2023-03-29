namespace Polymorphism.Animals
{
    class Animal
    {
        public virtual void MakeSound() =>
            Console.WriteLine(
                "Make a generic animal sound.");
    }

    class HousePet : Animal
    {
        public override void MakeSound() =>
                Console.WriteLine(
                    "<noises of happines when human comes home>");
    }

    class Feline : Animal
    {
        public override void MakeSound() =>
                Console.WriteLine("purr purr");
    }

    //cannot be derived from more than one base class
    class DomesticCat : Feline //, HousePet
    {

    }

    interface IAnimal
    {
        void MakeSound();
    }

    interface IHousePet : IAnimal
    {
        void TakeToVet();
    }

    interface IFeline : IAnimal
    {
        void HideInCardboardBox();
    }

    class DomesticCatImplementingInterfaces : IFeline, IHousePet
    {
        public void HideInCardboardBox() =>
            Console.WriteLine("Hide in any cardboard box in sight.");

        public void MakeSound()
        {
            Console.WriteLine("Purr purr.");
        }

        public void TakeToVet() =>
            Console.WriteLine("Take to Dr. Paws using a carrier.");
    }
}
