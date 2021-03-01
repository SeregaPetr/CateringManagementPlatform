namespace CateringManagementPlatform.BLL.Platform.DTO.TableInfoDtos
{
    public class TableInfoReadDto
    {
        public int TableId { get; set; }
        public int NumberTable { get; set; }
        public bool IsReservation { get; set; }
        public int CapacityTable { get; set; }
        public int? NumberGuests { get; set; }

        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
