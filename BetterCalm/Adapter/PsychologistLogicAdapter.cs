﻿using System;
using AdapterInterface;
using Model.In;
using Model.Out;

namespace Adapter
{
    public class PsychologistLogicAdapter : IPsychologistLogicAdapter
    {
        public PsychologistLogicAdapter()
        {
        }

        public PsychologistBasicInfoModel GetById(int psychologistId)
        {
            throw new NotImplementedException();
        }

        public PsychologistBasicInfoModel Add(PsychologistModel psychologistModel)
        {
            throw new NotImplementedException();
        }
    }
}
