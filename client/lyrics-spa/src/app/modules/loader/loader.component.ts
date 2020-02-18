import { Component, ChangeDetectorRef, AfterViewChecked } from '@angular/core';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements AfterViewChecked {
  ngAfterViewChecked(): void {
    this.c.detectChanges();
  }

  loading: boolean;
  constructor(private loaderService: LoaderService, private c: ChangeDetectorRef) {
    this.loaderService.isLoading
      .subscribe((v) => {
        this.loading = v;
      });
  }
}
