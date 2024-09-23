import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ImageEditor';
  // 読み込み対象画像ファイル
  imageFile: File | null = null;

  // 切り出し枠表示キャンバス
  cropLayerCanvas: HTMLCanvasElement | null = null;
  cropLayerContext: CanvasRenderingContext2D | null | undefined = null;
  // 切り出し枠リスト
  cropFrames: CropFrame[] = [];

  // 切り出し枠移動フラグ
  selector: boolean = false;

// ファイル選択イベント
// ファイルを読み込んでキャンバスへ描画する
fileChangeEvent(event: any): void {
  if(event.target === null){
    this.imageFile = null;
    return;
  }

  if(event.target.files.length === 0){
    this.imageFile = null;
    return;
  }

  const imageCanvas: HTMLCanvasElement | null = document.querySelector("#imageLayer");
  if(imageCanvas === null)
    return;

  const context: CanvasRenderingContext2D | null | undefined = imageCanvas.getContext("2d");
  if(context === null || context === undefined)
    return;

  this.render(event.target.files[0]).subscribe((dataUrl)=>{
    const image = new Image();
    image.onload = function(){
      context.drawImage(image, 0, 0);
    }
    image.src = dataUrl;
  })
}

// ファイルの内容を読み込んでdataUrlに変換する
render(imageFile: File):Observable<any>{
  return new Observable(observer => {
    let reader = new FileReader();
    reader.readAsDataURL(imageFile);
    reader.onload = function(){
      var dataUrl:any = reader.result;
      observer.next(dataUrl);
    }
  })
}

// 切り出し枠表示
showCropFrame(): void{
  this.cropLayerCanvas = document.querySelector("#cropLayer");
  if(this.cropLayerCanvas === null)
    return;

  this.cropLayerContext = this.cropLayerCanvas.getContext("2d");
  if(this.cropLayerContext === null || this.cropLayerContext === undefined)
    return;

  // 切り出し枠オブジェクト登録
  let cropLI = new CropFrame();
  cropLI.Name = "LI"
  cropLI.PositionX = 50;
  cropLI.PositionY = 50;
  cropLI.Width = 100;
  cropLI.Height = 100;
  this.cropFrames.push(cropLI);

  let cropLM = new CropFrame();
  cropLM.Name = "LM"
  cropLM.PositionX = 200;
  cropLM.PositionY = 50;
  cropLM.Width = 100;
  cropLM.Height = 100;
  this.cropFrames.push(cropLM);

  this.cropLayerContext.strokeStyle = "red";
  this.cropFrames.forEach(element => {
    this.cropLayerContext?.strokeRect(element.PositionX, element.PositionY, element.Width, element.Height);
  });

}

// 切り出し枠選択
selectCropFrame(event: MouseEvent): any{
  if(this.cropLayerCanvas === null || this.cropLayerCanvas === undefined)
    return;

  // 左マウスボタン以外は受け付けない
  if(event.button != 0)
    return;

  const canvasRect = this.cropLayerCanvas.getBoundingClientRect();
  const xPosition:number = event.clientX - canvasRect.left;
  const yPosition:number = event.clientY - canvasRect.top;

  this.selector = false;

  // クリックされた場所が切り取り枠の矩形範囲か確認
  if(this.getSelectedCropFrameName(xPosition, yPosition) != "")
    this.selector = true;

}

// 切り出し枠選択解除
unselectCropFrame(event: MouseEvent): any{
  this.selector = false;
}

// 切り出し枠の移動
moveCropFrame(event: MouseEvent): any{
  if(this.cropLayerContext === null || this.cropLayerContext === undefined)
    return;

  if(this.cropLayerCanvas === null)
    return;

  if(!this.selector)
    return;

  // マウスの移動量を取得
  let offsetX = event.movementX;
  let offsetY = event.movementY;

  if(offsetX === 0 && offsetY === 0)
    return;

  // 選択されている切り出し枠を特定
  const canvasRect = this.cropLayerCanvas.getBoundingClientRect();
  const xPosition:number = event.clientX - canvasRect.left;
  const yPosition:number = event.clientY - canvasRect.top;
  let selectedName = this.getSelectedCropFrameName(xPosition, yPosition);
  if(selectedName === "")
  {
    this.selector = false;
    return;
  }

  this.cropLayerContext.clearRect(0, 0, this.cropLayerCanvas.width, this.cropLayerCanvas.height);

  this.cropFrames.forEach(element =>{
    if(element.Name === selectedName){
      element.PositionX += offsetX;
      element.PositionY += offsetY;
    }

    this.cropLayerContext?.strokeRect(element.PositionX, element.PositionY, element.Width, element.Height);
  });
}

// 選択切り出し枠名取得
getSelectedCropFrameName(positionX: number, positionY: number): any {
  let result: string = "";
  this.cropFrames.forEach(element =>{
    if(element.PositionX <= positionX && positionX <= element.PositionX + element.Width){
      if(element.PositionY <= positionY && positionY <= element.PositionY + element.Height){
        result = element.Name;
      }
    }
  });

  return result;
}

cropImage(event: MouseEvent): any{
  // 元の画像を取得
  const imageCanvas: HTMLCanvasElement | null = document.querySelector("#imageLayer");
  if(imageCanvas === null)
    return;

  const context: CanvasRenderingContext2D | null | undefined = imageCanvas.getContext("2d");
  if(context === null || context === undefined)
    return;

  // 切り出し画像（LI）の表示先を取得
  const cropImageCanvas_LI: HTMLCanvasElement | null = document.querySelector("#cropImage_LI");
  if(cropImageCanvas_LI === null)
    return;

  const cropImageContext_LI: CanvasRenderingContext2D | null | undefined = cropImageCanvas_LI.getContext("2d");
  if(cropImageContext_LI === null || cropImageContext_LI === undefined)
    return;

  let cropFrame = this.cropFrames.find(element => element.Name === "LI");
  if(cropFrame != undefined){
    let cropImage = context.getImageData(cropFrame.PositionX, cropFrame.PositionY,cropFrame.Width, cropFrame.Height);
    cropImageContext_LI.putImageData(cropImage, 0, 0);
  }

  // 切り出し画像（LM）の表示先を取得
  const cropImageCanvas_LM: HTMLCanvasElement | null = document.querySelector("#cropImage_LM");
  if(cropImageCanvas_LM === null)
    return;

  const cropImageContext_LM: CanvasRenderingContext2D | null | undefined = cropImageCanvas_LM.getContext("2d");
  if(cropImageContext_LM === null || cropImageContext_LM === undefined)
    return;

  cropFrame = this.cropFrames.find(element => element.Name === "LM");
  if(cropFrame != undefined){
    let cropImage = context.getImageData(cropFrame.PositionX, cropFrame.PositionY,cropFrame.Width, cropFrame.Height);
    cropImageContext_LM.putImageData(cropImage, 0, 0);
  }

}

}

// 切り出し枠クラス
class CropFrame{
  public Name: string = "";
  public PositionX: number = 0;
  public PositionY: number = 0;
  public Width: number = 0;
  public Height: number = 0;
}
