namespace Restaurants.Application.Common
{
    public class PagedResult <T>
    {
        public PagedResult(IEnumerable<T> itemes, int totalCount, int pagezise, int pageNumber)
        {
            Items = itemes;
            TotalItemsCount = totalCount;
            TotalPages =(int)Math.Ceiling(totalCount / (double)pagezise); //math.celling(2.8) =.> 3
            ItemsFrom = pagezise * (pageNumber - 1);
            ItemsTo = ItemsFrom + pagezise - 1;
            //page size = 5
            //pahe number =2
            //skip: pagesize * (page number-1) => 5
            //itemsFrom: 5 =1 =>6
            //itemsTo: 6 + 5-1 => 10
        }
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount{ get; set; }
        public int ItemsFrom{ get; set; }
        public int ItemsTo{ get; set; }
    }
}
