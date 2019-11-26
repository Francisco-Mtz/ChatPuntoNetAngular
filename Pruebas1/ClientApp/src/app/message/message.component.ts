import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html'
})
export class MessageComponent {
  @Input() oMessage: Message;
}

interface Message {

  Id: number,
  Name: string,
  Message: string
}
