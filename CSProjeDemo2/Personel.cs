namespace CSProjeDemo2
{
    public abstract class Personel
    {
        public string Name { get; set; } = "";
        public string Title { get; set; } = "";
        public int WorkingHours { get; set; } = 0;
        public decimal HourlyRate { get; set; } = 0;
        public decimal Bonus { get; set; } = 0m;

        public abstract decimal MaasHesapla(decimal HourlyRate, int WorkingHours, decimal Bonus);
        public override string ToString()
        {
            return $"Personel Adı: {Name}, Ünvanı: {Title}";
        }

    }
}
