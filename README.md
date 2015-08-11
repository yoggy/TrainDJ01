TrainDJ01
====
[BSoD Version 2.0](http://bsod.fukuchilab.org/)で使用したUnityアセット一式。

* ![https://farm4.staticflickr.com/3685/20260383240_f8b9541795.jpg](https://farm4.staticflickr.com/3685/20260383240_f8b9541795.jpg)

DJが曲をつなぐように、車窓の風景をどんどんつないでいくと面白いのか？と思い作成した実験映像システム。

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
* (5) ビルドしてexeを作成
* (6) exeを実行中にFキーを押すとフルスクリーン表示切り替え
* (7) 演奏中はスリープしないように[Caffeine](http://www.zhornsoftware.co.uk/caffeine/)などを動かしておくと吉

screen
----
* ![https://farm4.staticflickr.com/3705/19825959254_67a81fff6c_z.jpg](https://farm4.staticflickr.com/3705/19825959254_67a81fff6c_z.jpg)

MIDI mapping
----
操作は[Launch Control](http://www.h-resolution.com/novation/launchcontrol.php)用にマッピングしています。

* ![https://farm1.staticflickr.com/420/20260223030_2fa51e7e0c_o.png](https://farm1.staticflickr.com/420/20260223030_2fa51e7e0c_o.png)

Unity Editorの"Window"->"Reaktion"を開き、表示されるUIから操作することもできます。

* ![https://farm1.staticflickr.com/327/20259863788_d1a67ab289_n.jpg](https://farm1.staticflickr.com/327/20259863788_d1a67ab289_n.jpg)

movies
----
TrainDJ01はA,B2つの動画を再生しておき、クロスフェーダーを使って車窓風景をつないでいくアナログDJのプレイスタイルを踏襲しています。

MainMovieControllerにはA,B共通で使用する動画を設定しておきます。
TransitionMovieControllerに設定する動画は、電車が通りすぎる動画の再生など、シーンの切り替え時に使用するトランジション動画を再生するために使用します。

映像素材はMP4ファイルとJPEGファイルをセットで用意する必要があります。
JPEGファイルは"動画ファイル名.mp4"+".jpg"という名前を設定しておきます。

* ![https://farm1.staticflickr.com/324/19826612163_f292133b8d.jpg](https://farm1.staticflickr.com/324/19826612163_f292133b8d.jpg)

JPEGファイルは[cv_breath_one](https://github.com/yoggy/cv_breath_one)を使ってスリットスキャン画像を作成しておきます。この画像は動画を選択する際のサムネイル表示に使われます。

* ![https://farm4.staticflickr.com/3833/19826695963_a9eb42d078_z.jpg](https://farm4.staticflickr.com/3833/19826695963_a9eb42d078_z.jpg)


[BSoD Version 2.0](http://bsod.fukuchilab.org/)で使用したMainMovieController用動画とTransitionMovieController用動画は以下のURLに置いています。

* [車窓風景動画(MainMovieController用)](http://www.sabamiso.net/yoggy/traindj01_movies.zip)
* [トランジション動画(TransitionMovieController用)](http://www.sabamiso.net/yoggy/traindj01_transitions.zip)


libraries
----
以下のライブラリを使用しています。

  * Reaktion
    * https://github.com/keijiro/Reaktion

  * BinaryImager
    * https://github.com/keijiro/BinaryImager

  * KinoFringe
    * https://github.com/keijiro/KinoFringe

inspired by
----
* The Chemical Brothers - Star Guitar
  * https://www.youtube.com/watch?v=0S43IwBF0uM

* ヨーロッパの車窓だけ
  * http://www.twellv.co.jp/event/shasou/

* HIMATSUBUSHI
  * http://archive.j-mediaarts.jp/festival/2011/art/works/15a_himatsubushi/
  * https://www.youtube.com/watch?v=Ps_U2BYWSn8

* とんかつDJアゲ太郎 第20皿
  * http://plus.shonenjump.com/rensai_detail.html?item_cd=SHSA_JP01PLUS00000007_57
