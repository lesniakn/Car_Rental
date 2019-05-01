namespace Car_Rental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cars
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Model { get; set; }

        [Required]
        [StringLength(10)]
        public string Nazwa { get; set; }

        public int Rok_produkcji { get; set; }

        public double Pojemnosc_silnika { get; set; }

        public int Moc { get; set; }

        public int Liczba_drzwi { get; set; }

        public int Cena { get; set; }
    }
}
