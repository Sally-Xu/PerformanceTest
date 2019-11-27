import { Injectable } from '@nestjs/common';

@Injectable()
export class AppService {
  buildList(n: number): any[] {
    let list = [];
    for(var i = 0; i < n; i++)
    {
      list.push("test" + i);
    }
    return list;
  } 
}
