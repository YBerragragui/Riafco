using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riafco.Dal.Dataflex.Pro.Interface;
using Riafco.Dal.Dataflex.Pro.Core;
using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Dal.Dataflex.Pro.Context;

namespace Riafco.Service.Dataflex.Pro.UnitOfWork
{
public class UnitOfWork : IUnitOfWork
{
private readonly OMSContext _context;

private IGenericRepository<Step> _StepRepository;

public UnitOfWork(OMSContext context)
{
 this._context = context;
}

public IGenericRepository<Step> StepRepository
{
 get{ return this._StepRepository ?? (this._StepRepository = new GenericRepository<Step>(_context)); } 
}

private IGenericRepository<StepParagraph> _StepParagraphRepository;

public IGenericRepository<StepParagraph> StepParagraphRepository
{
 get{ return this._StepParagraphRepository ?? (this._StepParagraphRepository = new GenericRepository<StepParagraph>(_context)); } 
}

private IGenericRepository<StepParagraphTranslation> _StepParagraphTranslationRepository;

public IGenericRepository<StepParagraphTranslation> StepParagraphTranslationRepository
{
 get{ return this._StepParagraphTranslationRepository ?? (this._StepParagraphTranslationRepository = new GenericRepository<StepParagraphTranslation>(_context)); } 
}

//IMETHODE



}
}
