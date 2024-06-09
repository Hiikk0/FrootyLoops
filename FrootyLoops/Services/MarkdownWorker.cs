using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Markdig;
using Neo.Markdig.Xaml;

namespace FrootyLoops.Services
{
    public class MarkdownWorker
    {
        public static FlowDocument MarkdownRender(string path) 
        {
            var content = File.ReadAllText(path);

            var pipeline = new MarkdownPipelineBuilder()
                .UseXamlSupportedExtensions()
                .Build();

            var doc = MarkdownXaml.ToFlowDocument(content, pipeline);

            return doc;
        }
    }
}
