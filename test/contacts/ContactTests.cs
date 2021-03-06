﻿using System;
using System.Collections.Generic;
using System.Linq;
using com.esendex.sdk.contacts;
using NUnit.Framework;

namespace com.esendex.sdk.test.contacts
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Contact_DefaultDIConstructor()
        {
            // Arrange
            string quickname = "quickname";
            string phonenumber = "phonenumber";

            // Act
            Contact contactInstance = new Contact(quickname, phonenumber);

            // Assert
            Assert.AreEqual(quickname, contactInstance.QuickName);
            Assert.AreEqual(phonenumber, contactInstance.PhoneNumber);
            Assert.That(contactInstance.Groups, Is.InstanceOf<IEnumerable<ContactGroupSummary>>());
        }

        [Test]
        public void Contact_DefaultDIConstructor_WithNullQuickNameAndMobileNumber_ThrowsException()
        {
            // Arrange
            string quickname = string.Empty;
            string phonenumber = null;

            // Act
            try
            {
                Contact contactInstance = new Contact(quickname, phonenumber);

                Assert.Fail();
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("quickName", ex.ParamName);
            }
        }

        [Test]
        public void ContactCollection_DefaultConstructor()
        {
            // Arrange

            // Act
            ContactCollection contactCollectionInstance = new ContactCollection();

            // Assert
            Assert.That(contactCollectionInstance.Items, Is.InstanceOf<List<Contact>>());
        }

        [Test]
        public void ContactCollection_DefaultDIConstructor_WithContact()
        {
            // Arrange
            Contact contact = new Contact();

            // Act
            ContactCollection contactCollectionInstance = new ContactCollection(contact);

            // Assert
            Assert.AreEqual(contact, contactCollectionInstance.Items.ElementAt(0));
        }

        [Test]
        public void ContactCollection_DefaultDIConstructor_WithNullContact_ThrowsArgumentNullException()
        {
            // Arrange
            Contact contact = null;

            // Act
            try
            {
                ContactCollection contactCollectionInstance = new ContactCollection(contact);

                Assert.Fail();
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("contact", ex.ParamName);
            }
        }

        [Test]
        public void ContactCollection_DefaultDIConstructor_WithContactsArray()
        {
            // Arrange
            Contact contact = new Contact();

            List<Contact> contacts = new List<Contact>();

            contacts.Add(contact);

            // Act
            ContactCollection contactCollectionInstance = new ContactCollection(contacts);

            // Assert
            Assert.AreEqual(contact, contactCollectionInstance.Items.ElementAt(0));
        }

        [Test]
        public void ContactCollection_DefaultDIConstructor_WithNullContactArray_ThrowsArgumentNullException()
        {
            // Arrange
            List<Contact> contacts = null;

            // Act
            try
            {
                ContactCollection contactCollectionInstance = new ContactCollection(contacts);

                Assert.Fail();
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("contacts", ex.ParamName);
            }
        }
    }
}