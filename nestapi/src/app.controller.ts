import { Controller, Get, Param } from '@nestjs/common';
import { AppService } from './app.service';

@Controller('nest')
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get(':n')
  getList(@Param() params): any[] {
    return this.appService.buildList(params.n);
  }
}
