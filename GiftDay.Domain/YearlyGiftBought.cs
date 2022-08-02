using BitOfA.Helper.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Domain {
    public class YearlyGiftBought : DomainBase {

        public YearlyGiftBought(bool bought, int year) {
            Bought = bought;
            Year = year;
        }

        public int Year { get; set; }
        public bool Bought { get; set; }
    }
}
