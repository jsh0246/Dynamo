﻿using System;
using System.IO;
using System.Xml;
using Dynamo.Models;
using NUnit.Framework;

namespace Dynamo.Tests
{
    class WorkspaceHeaderTests : DynamoViewModelUnitTest
    {
        [Test]
        public void CanRecognizeCustomNodeWorkspace()
        {
            var examplePath = Path.Combine(GetTestDirectory(), @"core\combine", "Sequence2.dyf");
            var doc = new XmlDocument();
            doc.Load(examplePath);
            WorkspaceHeader workspaceInfo;
            Assert.IsTrue(WorkspaceHeader.FromXmlDocument(doc, examplePath, true, ViewModel.Model.Logger, out workspaceInfo));

            Assert.AreEqual(workspaceInfo.Name, "Sequence2");
            Assert.AreEqual(workspaceInfo.ID, "6aecda57-7679-4afb-aa02-05a75cc3433e");
            Assert.IsTrue(workspaceInfo.IsCustomNodeWorkspace);
        }

        [Test]
        public void CanRecognizeHomeWorkspace()
        {
            var examplePath = Path.Combine(GetTestDirectory(), @"core\combine", "combine-with-three.dyn");
            var doc = new XmlDocument();
            doc.Load(examplePath); WorkspaceHeader workspaceInfo;
            Assert.IsTrue(WorkspaceHeader.FromXmlDocument(doc, examplePath, true, ViewModel.Model.Logger, out workspaceInfo));

            Assert.AreEqual("Home", workspaceInfo.Name);
            Assert.IsTrue( String.IsNullOrEmpty(workspaceInfo.ID) );
            Assert.IsFalse(workspaceInfo.IsCustomNodeWorkspace);
        }
    }
}
