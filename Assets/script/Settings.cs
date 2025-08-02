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
        // Открываем галерею для выбора изображения
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                FileInfo fileInfo = new FileInfo(path);
                long fileSizeInBytes = fileInfo.Length;
                const long maxSizeInBytes = 36 * 1024; // 100 КБ в байтах
                if (fileSizeInBytes > maxSizeInBytes)
                {
                    StartCoroutine(SizeFilePerm());
                }
                else
                {
                    // Загружаем выбранное изображение
                    Texture2D texture = NativeGallery.LoadImageAtPath(path, 256, false);
                    if (texture != null)
                    {
                        // Устанавливаем текстуру в UI
                        // avatarImage.texture = texture;

                        // Отправляем текстуру на сервер
                        SendAvatarToServer(texture);
                    }
                }
                
            }
        }, "Выберите аватарку, до 36 КБ", "image/*");
    }

    private void SendAvatarToServer(Texture2D texture)
    {
        // Конвертируем в JPG с качеством 75%
        byte[] jpgData = texture.EncodeToJPG(3); // Качество от 1 (низкое) до 100 (высокое)

        // Если нужно именно в PNG - конвертируем обратно
        //Texture2D compressedTexture = new Texture2D(2, 2);
        //compressedTexture.LoadImage(jpgData); // Автоматически декодирует JPG
        //byte[] pngData = compressedTexture.EncodeToPNG();
        //Destroy(compressedTexture);

        // Конвертируем текстуру в массив байтов
        //byte[] imageData = texture.EncodeToPNG();
        ClientSend.UpdateAvatar(jpgData);
        // Отправляем данные на сервер
        // (Реализация TCP-клиента будет ниже)
    }

    public IEnumerator SizeFilePerm()
    {
        SizeBig.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SizeBig.SetActive(false);
    }

}
