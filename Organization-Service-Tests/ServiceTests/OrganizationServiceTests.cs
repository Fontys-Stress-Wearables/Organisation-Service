using System;
using System.Collections.Generic;
using Moq;
using Newtonsoft.Json;
using Organization_Service.Data;
using Organization_Service.Exceptions;
using Organization_Service.Interfaces;
using Organization_Service.Models;
using Organization_Service.Services;
using Xunit;

namespace Organization_Service_Tests;

public class OrganizationServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
    private readonly Mock<INatsService> _natsService = new Mock<INatsService>();

    [Fact]
    public void GetAll_ShouldSucceed()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var organizationList = new List<Organization>() { organization };
        _unitOfWork.Setup(x => x.Organizations.GetAll()).Returns(organizationList);

        // Act
        var result = organizationService.GetAll();
        
        // Assert
        _unitOfWork.Verify(x => x.Organizations.GetAll(), Times.Once);
        Assert.Equal(organizationList, result);
    }
    
    [Fact]
    public void GetOrganization_ShouldSucceed()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var testId = "testId";
        organization.Id = testId;
        _unitOfWork.Setup(x => x.Organizations.GetById(testId)).Returns(organization);

        // Act
        var result = organizationService.GetOrganization(testId);
        
        // Assert
        _unitOfWork.Verify(x => x.Organizations.GetById(testId), Times.Once);
        Assert.Equal(organization, result);
        Assert.Equal(testId, organization.Id);
    }
    
    [Fact]
    public void GetOrganization_ShouldThrowNotFoundException()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var testId = "testId";
        organization.Id = testId;
        _unitOfWork.Setup(x => x.Organizations.GetById(testId)).Returns(() => null);

        // Act
        var result = Assert.Throws<NotFoundException>(() =>
            organizationService.GetOrganization(testId)
        );
        
        // Assert
        _unitOfWork.Verify(x => x.Organizations.GetById(testId), Times.Once);
        Assert.Equal($"Organization with id '{testId}' doesn't exist.", result.Message);
    }
    
    [Fact]
    public void CreateOrganization_ShouldSucceed()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var testId = "testId";
        organization.Id = testId;
        var testName = "testName";
        organization.Name = testName;
        _unitOfWork.Setup(x => x.Organizations.Add(organization)).Returns(() => null);

        // Act
        var result = organizationService.CreateOrganization(testId, testName);
        
        // Assert
        _unitOfWork.Verify(x => x.Complete(), Times.Once);
        Assert.Equal(JsonConvert.SerializeObject(organization), JsonConvert.SerializeObject(result));
    }
    
    [Fact]
    public void CreateOrganization_ShouldThrowBadRequestExceptionForEmptyId()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var testId = String.Empty;
        var testName = "testName";
        
        // Act
        var result = Assert.Throws<BadRequestException>(() =>
            organizationService.CreateOrganization(testId, testName)
        );
        
        // Assert
        Assert.Equal("Id cannot be empty.", result.Message);
    }
    
    [Fact]
    public void CreateOrganization_ShouldThrowBadRequestExceptionForEmptyName()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var testId = "testId";
        var testName = String.Empty;
        
        // Act
        var result = Assert.Throws<BadRequestException>(() =>
            organizationService.CreateOrganization(testId, testName)
        );
        
        // Assert
        Assert.Equal("Name cannot be empty.", result.Message);
    }
    
    [Fact]
    public void UpdateOrganizationName_ShouldSucceed()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var testId = "testId";
        organization.Id = testId;
        var testName = "testName";
        organization.Name = testName;
        _unitOfWork.Setup(x => x.Organizations.GetById(testId)).Returns(organization);
    
        // Act
        var result = organizationService.UpdateOrganizationName(testId, testName);
        
        // Assert
        _unitOfWork.Verify(x => x.Complete(), Times.Once);
        Assert.Equal(organization, result);
    }
    
    [Fact]
    public void UpdateOrganizationName_ShouldThrowNotFoundException()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var testId = "testId";
        var testName = "testName";
        _unitOfWork.Setup(x => x.Organizations.GetById(testId)).Returns(() => null);
        
        // Act
        var result = Assert.Throws<NotFoundException>(() =>
            organizationService.UpdateOrganizationName(testId, testName)
        );
        
        // Assert
        _unitOfWork.Verify(x => x.Organizations.GetById(testId), Times.Once);
        Assert.Equal($"Organization with id '{testId}' doesn't exist.", result.Message);
    }
    
    [Fact]
    public void RemoveOrganization_ShouldSucceed()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var testId = "testId";
        organization.Id = testId;
        _unitOfWork.Setup(x => x.Organizations.GetById(testId)).Returns(organization);

        // Act
        organizationService.RemoveOrganization(testId);
        
        // Assert
        _unitOfWork.Verify(x => x.Complete(), Times.Once);
    }
    
    [Fact]
    public void RemoveOrganization_ShouldThrowNotFoundException()
    {
        // Arrange
        var organizationService = new OrganizationService(_unitOfWork.Object, _natsService.Object);
        var organization = new Organization();
        var testId = "testId";
        organization.Id = testId;
        _unitOfWork.Setup(x => x.Organizations.GetById(testId)).Returns(() => null);

        // Act
        var result = Assert.Throws<NotFoundException>(() =>
            organizationService.RemoveOrganization(testId)
        );
        
        // Assert
        _unitOfWork.Verify(x => x.Organizations.GetById(testId), Times.Once);
        Assert.Equal($"Organization with id '{testId}' doesn't exist.", result.Message);
    }
}