using Assets.Builder_mainProject._1Scripts._1DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIExampleScene : MonoBehaviour
{
    public void Init(DIContainer projectContainer)
    {
        // ���������� ������� �������, ����� ��������� ��,��� ��� ����
        // ����� resolve - ����� � ������� ������ MyProjectService
        var serviceWithoutTag = projectContainer.Resolve<MyProjectService>();
        var service1 = projectContainer.Resolve<MyProjectService>("Option_1");
        var service2 = projectContainer.Resolve<MyProjectService>("Option_2");
    }
}
