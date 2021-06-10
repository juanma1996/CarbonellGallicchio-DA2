using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace Adapter
{
    public class BonusLogicAdapter : IBonusLogicAdapter
    {
        private readonly IBonusLogic bonusLogic;
        private readonly IMapper mapper;

        public BonusLogicAdapter(IBonusLogic bonusLogic, IModelMapper mapper)
        {
            this.bonusLogic = bonusLogic;
            this.mapper = mapper.Configure();
        }

        public List<BonusBasicInfoModel> GetAll()
        {
            List<Pacient> pacients = bonusLogic.GetAll();
            List<BonusBasicInfoModel> bonuses = mapper.Map<List<Pacient>, List<BonusBasicInfoModel>>(pacients);

            return bonuses;
        }

        public void Update(BonusModel bonusModel)
        {
            try
            {
                bonusLogic.Update(bonusModel.PacientId, bonusModel.Approved, bonusModel.Amount);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}
