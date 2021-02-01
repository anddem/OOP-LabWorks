namespace LabWork_10
{
    interface IExecutable
    {
        string Name { get; set; } //Название

        void PrintInfo(); //Вывод информации (не виртуальный)

        void PrintInformation(); //Вывод информации

        object ShallowCopy(); //Поверхностное копирование
    }
}
