using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Entity.Dataflex.Pro.News;
using Riafco.Entity.Dataflex.Pro.Newsletters;
using Riafco.Entity.Dataflex.Pro.Occurrences;
using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Framework.Dataflex.pro.Configuration;
using Riafco.Framework.Dataflex.pro.Configuration.Section;
using Riafco.Framework.Dataflex.pro.Configuration.Section.Assembler;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Riafco.Dal.Dataflex.Pro.Context
{
    /// <summary>
    /// The riafco context classe.
    /// </summary>
    public class RiafcoContext : DbContext
    {
        #region contructors
        public RiafcoContext() : base("RiafcoContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiafcoContext"/> class.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public RiafcoContext(string connectionString)
            : base(connectionString)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }
        #endregion

        /// <summary>
        /// Creat model.
        /// </summary>
        /// <param name="modelBuilder">model builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                base.OnModelCreating(modelBuilder);
                OnUserModelCreating(modelBuilder);
                OnAcvtivityModelCreating(modelBuilder);
                OnNewsModelCreating(modelBuilder);
                OnOccurrenceModelCreating(modelBuilder);
                OnRessourceModelCreating(modelBuilder);
                OnCountryModelCreating(modelBuilder);
                OnSectionModelCreating(modelBuilder);
                OnNewsletterModelCreating(modelBuilder);
                OnAboutModelCreating(modelBuilder);
                OnStepModelCreating(modelBuilder);

                modelBuilder.HasDefaultSchema(ConfigurationManagerHelper.GetAppSettingsToString(Constant.OmsDefaultSchema, string.Empty));
                modelBuilder.Properties().Where(p => p.PropertyType == typeof(string) && p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length == 0).Configure(p => p.HasMaxLength(int.MaxValue));
                var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
                var activeServices = ServiceActivation.GetAllActivatedServices().ToList();
                foreach (var service in activeServices)
                {
                    var entityAssembly = ServiceSettings.GetEntityAssembly(service);
                    var dependencies = ServiceSettings.GetAllServiceDependencies(service).ToSystemTypeList(entityAssembly);
                    foreach (var type in dependencies)
                    {
                        if (entityMethod != null)
                            entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
                    }
                    var configs = ServiceSettings.GetAllServiceConfigurationDependencies(service).ToSystemTypeList(entityAssembly);
                    foreach (var type in configs)
                    {
                        dynamic configurationInstance = Activator.CreateInstance(type);
                        modelBuilder.Configurations.Add(configurationInstance);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Configure user cascade 
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnUserModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRule>().HasRequired(s => s.User).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<UserRule>().HasRequired(s => s.Rule).WithMany().WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure activity cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnAcvtivityModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityTranslation>().HasRequired(s => s.Activity).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<ActivityTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ActivityParagraph>().HasRequired(s => s.Activity).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<ActivityParagraphTranslation>().HasRequired(s => s.ActivityParagraph).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<ActivityParagraphTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ActivityFile>().HasRequired(s => s.Activity).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<ActivityFileTranslation>().HasRequired(s => s.ActivityFile).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<ActivityFileTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure about cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnAboutModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SectionFile>().HasRequired(s => s.Section).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<SectionTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionTranslation>().HasRequired(s => s.Section).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<SectionFileTranslation>().HasRequired(s => s.SectionFile).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionFileTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SectionParagraph>().HasRequired(s => s.Section).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<SectionParagraphTranslation>().HasRequired(s => s.SectionParagraph).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionParagraphTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure news cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnNewsModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsTranslation>().HasRequired(s => s.News).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<NewsTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure news cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnOccurrenceModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OccurrenceTranslation>().HasRequired(s => s.Occurrence).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<OccurrenceTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure ressource cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnRessourceModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaTranslation>().HasRequired(s => s.Area).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<AreaTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<ThemeTranslation>().HasRequired(s => s.Theme).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<ThemeTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<Publication>().HasRequired(s => s.Author).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<Publication>().HasRequired(s => s.Area).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<PublicationTranslation>().HasRequired(s => s.Publication).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<PublicationTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PublicationTheme>().HasRequired(s => s.Publication).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<PublicationTheme>().HasRequired(s => s.Theme).WithMany().WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure news cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnCountryModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryTranslation>().HasRequired(s => s.Country).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<CountryTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<Sheet>().HasRequired(s => s.Country).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<SheetTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<SheetTranslation>().HasRequired(s => s.Sheet).WithMany().WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure news cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnSectionModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SectionTranslation>().HasRequired(s => s.Section).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionTranslation>().HasRequired(s => s.Language).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<SectionParagraph>().HasRequired(s => s.Section).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionParagraphTranslation>().HasRequired(s => s.SectionParagraph).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionParagraphTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SectionFile>().HasRequired(s => s.Section).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionFileTranslation>().HasRequired(s => s.SectionFile).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<SectionFileTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure step cascading.
        /// </summary>
        /// <param name="modelBuilder">the model builder to configure.</param>
        private void OnStepModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepParagraph>().HasRequired(s => s.Step).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<StepParagraphTranslation>().HasRequired(s => s.StepParagraph).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<StepParagraphTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Configure news cascade.
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        private void OnNewsletterModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsletterMailTranslation>().HasRequired(s => s.NewsletterMail).WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<NewsletterMailTranslation>().HasRequired(s => s.Language).WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}
