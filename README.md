TrainDJ01
====
[BSoD Version 2.0](http://bsod.fukuchilab.org/)で使用したUnityアセット一式。

* ![https://farm4.staticflickr.com/3685/20260383240_f8b9541795.jpg](https://farm4.staticflickr.com/3685/20260383240_f8b9541795.jpg)

memo
----
* (1) 動画の再生に必要なLAVFilterをインストールしておく
  * https://github.com/Nevcairiel/LAVFilters/releases
* (2) プロジェクトを開いたら、AVPro Windowsをimportする
  * http://www.renderheads.com/portfolio/UnityAVProWindowsMedia/
  * Free trial版でも動きます
* (3) TrainDJ01/TrainDJ01.sceneがシーン本体なのでこれを開く
* (4) MainMovieControllerとTransitionMovieControllerに映像素材があるディレクトリを設定
  * プロパティ"target Directory"の項目

movies
----
映像素材はMP4ファイルとJPEGファイルをセットで用意する必要があります。
JPEGファイルは"動画ファイル名.mp4"+".jpg"という名前を設定しておきます。

* ![https://farm1.staticflickr.com/324/19826612163_f292133b8d.jpg](https://farm1.staticflickr.com/324/19826612163_f292133b8d.jpg)

JPEGファイルは[cv_breath_one](https://github.com/yoggy/cv_breath_one)を使ってスリットスキャン画像を作成しておきます。この画像は動画を選択する際のサムネイル表示に使われます。

* ![https://farm4.staticflickr.com/3833/19826695963_a9eb42d078_z.jpg](https://farm4.staticflickr.com/3833/19826695963_a9eb42d078_z.jpg)

MIDI mapping
----
操作は[Launch Control](http://www.h-resolution.com/novation/launchcontrol.php)用にマッピングしています。

* ![https://farm1.staticflickr.com/420/20260223030_2fa51e7e0c_o.png](https://farm1.staticflickr.com/420/20260223030_2fa51e7e0c_o.png)

Unity Editorの"Window"->"Reaktion"を開き、表示されるUIから操作することもできます。

* ![https://farm1.staticflickr.com/327/20259863788_d1a67ab289_n.jpg](https://farm1.staticflickr.com/327/20259863788_d1a67ab289_n.jpg)

screen
----
* ![https://farm4.staticflickr.com/3705/19825959254_67a81fff6c_z.jpg](https://farm4.staticflickr.com/3705/19825959254_67a81fff6c_z.jpg)


libraries
----
以下のライブラリを使用しています。

  * Reaktion
    * https://github.com/keijiro/Reaktion

  * BinaryImager
    * https://github.com/keijiro/BinaryImager

  * KinoFringe
    * https://github.com/keijiro/KinoFringe