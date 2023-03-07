﻿using System;
using System.Runtime.Serialization;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Metadata;
using Avalonia.Styling;
using Dock.Model.Controls;

namespace Dock.Model.Avalonia.Controls;

/// <summary>
/// Document template.
/// </summary>
[DataContract(IsReference = true)]
public sealed class DocumentTemplate : IDocumentTemplate, ITemplate<Control>, IRecyclingDataTemplate
{
    /// <summary>
    /// Initializes new instance of the <see cref="DocumentTemplate"/> class.
    /// </summary>
    public DocumentTemplate()
    {
    }

    /// <summary>
    /// Gets or sets document content.
    /// </summary>
    [Content]
    [TemplateContent]
    [ResolveByName]
    [IgnoreDataMember]
    public object? Content { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember]
    public Type? DataType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Control Build()
    {
        return (Control)Load(Content).Control;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    object ITemplate.Build() => Build();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool Match(object? data)
    {
        if (DataType == null)
        {
            return true;
        }

        return DataType.IsInstanceOfType(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public Control Build(object? data) => Build(data, null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="existing"></param>
    /// <returns></returns>
    public Control Build(object? data, Control? existing)
    {
        return existing ?? TemplateContent.Load(Content)?.Control!;
    }

    private static ControlTemplateResult Load(object templateContent)
    {
        if (templateContent is Func<IServiceProvider, object> direct)
        {
            return (ControlTemplateResult)direct(null!);
        }
        throw new ArgumentException(nameof(templateContent));
    }
}
