import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-select-attribute',
  templateUrl: './select-attribute.component.html',
  styleUrls: ['./select-attribute.component.css']
})
export class SelectAttributeComponent  {
  attributes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vel aliquet mi. Quisque eu ornare leo. Suspendisse sagittis sollicitudin ante, in varius dolor fermentum et. Nam a nibh facilisis sapien convallis auctor. Donec velit lacus, tristique in tempus vel, pulvinar vitae tortor. Phasellus quis dictum sapien. Etiam varius, lectus a hendrerit lobortis, nulla tortor egestas ligula, quis vestibulum felis neque commodo risus. Curabitur viverra pellentesque libero ac feugiat. Curabitur ut scelerisque orci. Duis feugiat eleifend justo, sit amet hendrerit elit bibendum eu. Curabitur lacus massa, semper a venenatis et, sagittis condimentum risus. Aliquam non metus id justo ultrices ultricies. Nunc ornare molestie nisi eu vestibulum."
    .split(" ")
    .map((attribute, index) => ({
      attribute: attribute,
      id: index
    }))

  currentAttribute = 0
  
  changeCurrentAttribute(id: number) {
    this.currentAttribute = id;
    
  }
}
