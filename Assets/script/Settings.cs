using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NativeGalleryNamespace;
using System.Text;
using System.IO;

public class Settings : MonoBehaviour
{
    public RawImage avatarImage;
    public GameObject SizeBig;
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void ExitServer()
    {
        PlayerPrefs.DeleteKey("mail");
        PlayerPrefs.DeleteKey("GameServerIp");
        SceneManager.LoadScene(0);
    }

    public void OpenImageAvatar()
    {
        // ��������� ������� ��� ������ �����������
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                FileInfo fileInfo = new FileInfo(path);
                long fileSizeInBytes = fileInfo.Length;
                const long maxSizeInBytes = 36 * 1024; // 100 �� � ������
                if (fileSizeInBytes > maxSizeInBytes)
                {
                    StartCoroutine(SizeFilePerm());
                }
                else
                {
                    // ��������� ��������� �����������
                    Texture2D texture = NativeGallery.LoadImageAtPath(path, 256, false);
                    if (texture != null)
                    {
                        // ������������� �������� � UI
                        // avatarImage.texture = texture;

                        // ���������� �������� �� ������
                        SendAvatarToServer(texture);
                    }
                }
                
            }
        }, "�������� ��������, �� 36 ��", "image/*");
    }

    private void SendAvatarToServer(Texture2D texture)
    {
        // ������������ � JPG � ��������� 75%
        byte[] jpgData = texture.EncodeToJPG(3); // �������� �� 1 (������) �� 100 (�������)

        // ���� ����� ������ � PNG - ������������ �������
        //Texture2D compressedTexture = new Texture2D(2, 2);
        //compressedTexture.LoadImage(jpgData); // ������������� ���������� JPG
        //byte[] pngData = compressedTexture.EncodeToPNG();
        //Destroy(compressedTexture);

        // ������������ �������� � ������ ������
        //byte[] imageData = texture.EncodeToPNG();
        ClientSend.UpdateAvatar(jpgData);
        // ���������� ������ �� ������
        // (���������� TCP-������� ����� ����)
    }

    public IEnumerator SizeFilePerm()
    {
        SizeBig.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SizeBig.SetActive(false);
    }

}
