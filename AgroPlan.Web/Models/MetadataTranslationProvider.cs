using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models
{
    public class MetadataTranslationProvider : IValidationMetadataProvider
    {
        private readonly ResourceManager _resourceManager;
        private readonly Type _resourceType;

        public MetadataTranslationProvider(Type type)
        {
            _resourceType = type;
            _resourceManager = new ResourceManager(type);
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                if (attribute is ValidationAttribute tAttr)
                {
                    // search a ressource that corresponds to the attribute type name
                    if (tAttr.ErrorMessage == null && tAttr.ErrorMessageResourceName == null)
                    {
                        var name = tAttr.GetType().Name;
                        if (_resourceManager.GetString(name) != null)
                        {
                            tAttr.ErrorMessageResourceType = _resourceType;
                            tAttr.ErrorMessageResourceName = name;
                            tAttr.ErrorMessage = null;
                        }
                    }
                }
            }
        }
    }
}
