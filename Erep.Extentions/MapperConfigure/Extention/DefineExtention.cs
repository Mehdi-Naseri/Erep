using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Erep.DomainClasses.Models;
using Erep.ViewModels.ViewModels;

namespace Erep.Extentions.MapperConfigure.Extention
{
    public static class DefineExtention
    {
        #region Project
        public static ScammerViewModel MapModelToViewModel(this Scammer entity)
        {
            return Mapper.Map<Scammer, ScammerViewModel>(entity);
        }
        public static Scammer MapViewModelToModel(this ScammerViewModel entity)
        {
            return Mapper.Map<ScammerViewModel, Scammer>(entity);
        }
        public static IEnumerable<ScammerViewModel> MapModelToViewModel(this IEnumerable<Scammer> entity)
        {
            return Mapper.Map<IEnumerable<Scammer>, IEnumerable<ScammerViewModel>>(entity);
        }
        public static IEnumerable<Scammer> MapViewModelToModel(this IEnumerable<ScammerViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ScammerViewModel>, IEnumerable<Scammer>>(entity);
        }
        #endregion
    }
}
