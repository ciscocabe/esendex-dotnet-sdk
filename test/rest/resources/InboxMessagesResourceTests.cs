﻿using System;
using com.esendex.sdk.inbox;
using com.esendex.sdk.rest;
using com.esendex.sdk.rest.resources;
using NUnit.Framework;

namespace com.esendex.sdk.test.rest.resources
{
    [TestFixture]
    public class InboxMessagesResourceTests
    {
        [Test]
        public void DefaultConstructor()
        {
            // Arrange
            string expectedResourcePath = "inbox/messages";

            // Act
            RestResource resource = new InboxMessagesResource();

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }

        [Test]
        public void DefaultConstructor_WithPageNumber1AndPageSize()
        {
            // Arrange
            int pageNumber = 1;
            int pageSize = 15;

            string expectedResourcePath = string.Format("inbox/messages?startIndex=0&count={0}", pageSize);

            // Act
            RestResource resource = new InboxMessagesResource(pageNumber, pageSize);

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }

        [Test]
        public void DefaultConstructor_WithPageNumber2AndPageSize()
        {
            // Arrange
            int pageNumber = 2;
            int pageSize = 15;

            string expectedResourcePath = string.Format("inbox/messages?startIndex=15&count={0}", pageSize);

            // Act
            RestResource resource = new InboxMessagesResource(pageNumber, pageSize);

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }

        [Test]
        public void DefaultConstructor_WithInvalidPageNumberAndPageSize()
        {
            // Arrange
            int pageNumber = 0;
            int pageSize = 0;

            // Act
            try
            {
                RestResource resource = new InboxMessagesResource(pageNumber, pageSize);

                Assert.Fail();
            }
            // Assert
            catch (ArgumentException ex)
            {
                Assert.AreEqual("pageNumber", ex.ParamName);
            }
        }

        [Test]
        public void DefaultConstructor_WithAccountReference()
        {
            // Arrange
            string accountReference = "accountReference";

            string expectedResourcePath = string.Format("inbox/{0}/messages", accountReference);

            // Act
            RestResource resource = new InboxMessagesResource(accountReference);

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }

        [Test]
        public void DefaultConstructor_WithNullAccountReference()
        {
            // Arrange
            string accountReference = null;
            
            // Act
            try
            {
                RestResource resource = new InboxMessagesResource(accountReference);

                Assert.Fail();
            }
            // Assert
            catch (ArgumentException ex)
            {
                Assert.AreEqual("accountReference", ex.ParamName);
            }
        }

        [Test]
        public void DefaultConstructor_WithAccountReferenceAndPageNumberAndPageSize()
        {
            // Arrange
            string accountReference = "accountReference";
            int pageNumber = 2;
            int pageSize = 15;

            string expectedResourcePath = string.Format("inbox/{0}/messages?startIndex=15&count={1}", accountReference, pageSize);

            // Act
            RestResource resource = new InboxMessagesResource(accountReference, pageNumber, pageSize);

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }

        [Test]
        public void DefaultConstructor_WithIdAndInboxMessageStatus()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            string expectedResourcePath = string.Format("inbox/messages/{0}?action=read", id);

            // Act
            RestResource resource = new InboxMessagesResource(id, InboxMessageStatus.Read);

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }

        [Test]
        public void DefaultConstructor_WithId()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            string expectedResourcePath = string.Format("inbox/messages/{0}", id);

            // Act
            RestResource resource = new InboxMessagesResource(id);

            // Assert
            Assert.AreEqual(expectedResourcePath, resource.ResourcePath);
        }
    }
}
