using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riafco.Dal.Dataflex.Pro.Interface;
using Riafco.Entity.Dataflex.Pro.About;

namespace Riafco.Service.Dataflex.Pro.UnitOfWork
{
public interface IUnitOfWork : IDisposable
{
IGenericRepository<Step> StepRepository { get; }
IGenericRepository<StepParagraph> StepParagraphRepository { get; }
IGenericRepository<StepParagraphTranslation> StepParagraphTranslationRepository { get; }
//IMETHODE


void Save();

}
}
