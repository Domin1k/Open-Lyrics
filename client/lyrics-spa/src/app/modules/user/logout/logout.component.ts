import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-logout',
  template: ''
})
export class LogoutComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.userService.logout().subscribe(() => {
      this.snackBar.open('User logged out successfully', '', {duration: 1500, verticalPosition: 'top'})
      this.router.navigate(['user/login']);
    });
  }
}
