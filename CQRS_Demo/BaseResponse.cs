using CQRS_Demo.Entities.Interfaces;

namespace CQRS_Demo
{
    public class BaseResponse<TEntity>
    {
        public TEntity Data { get; set; }
        public int ResponseCode { get; set; }

        public BaseResponse(TEntity data)
        {
            this.Data = data;

            if (data is null)
            {
                ResponseCode = 500;
            }
        }
    }
}
