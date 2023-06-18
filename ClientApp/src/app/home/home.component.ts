import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, every } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { UserDTO } from 'src/models/UserDTO.model';
import { PostComments } from 'src/models/post-comments.model';
import { Post } from 'src/models/post.model';
import { PostCommentsService } from 'src/services/post-comments.service';
import { PostService } from 'src/services/post.service';
import { UserAttributesService } from 'src/services/user-attributes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userProfilePicture$!: string;
  defaultUserProfile$!: string;
  userDetails!: UserDTO;

  displayConfirmationDialog: boolean = false;

  user!: UserDTO;
  loggedInUserId!: any;

  posts: Post[] = [];
  postList!: Observable<Post[]>;
  postId: any;
  postIdToDelete: any;

  comments: PostComments[] = [];
  commentList!: Observable<PostComments[]>;
  commentId: any;
  commentIdToDelete: any;

  visible!: boolean;
  isSubmiting: boolean = false;

  displayAddPostModal: boolean = false;
  displayEditPostModal: boolean = false;

  displayAddCommentModal: boolean = false;
  displayEditCommentModal: boolean = false;

  addPostForm = new FormGroup({
    postContent: new FormControl('', Validators.required)
  });

  addCommentForm = new FormGroup({
    content: new FormControl('', Validators.required)
  });

  editPostForm = new FormGroup({
    postContent: new FormControl('', Validators.required),
  });

  editCommentForm = new FormGroup({
    content: new FormControl('', Validators.required)
  });

  showDialog() {
    this.visible = true;
  }

  constructor(
    private authService: AuthorizeService,
    private userService: UserAttributesService,
    private postService: PostService,
    private postCommentService: PostCommentsService
  ) {}

  ngOnInit(): void {
    this.refreshHomePage();
    this.loadUserDetailsForPosts();
    this.defaultUserProfile$ = 'assets/profile-placeholder.png';
    this.userService.getLoggedInUserData().subscribe((user) => {
      this.userDetails = user;
      this.userProfilePicture$ = this.userDetails.profileImageUrl;
    });
  }

  httpGetPosts() {
    this.postService.getAllPosts().subscribe({
      next: (posts) => {
        this.posts = posts;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  httpAddPosts() {
    if (this.addPostForm.valid && !this.isSubmiting) {
      this.authService.getUserId().subscribe((userId: string | null) => {
        if (userId) {
          const newPost: Post = {
            content: this.addPostForm.controls.postContent.value!,
            userId: userId,
            user: this.user
          };
          this.postService.createPost(newPost).subscribe(
            () => {
              console.log('Post added successfully');
              this.refreshHomePage();
            },
            (error: any) => {
              console.error('Failed to add post: ', error);
              this.isSubmiting = false;
            }
          );
          this.addPostForm.reset();
          this.hideAddPostModal();
        }
      });
    }
  }

  refreshHomePage(): void {
    this.postService.getAllPosts().subscribe({
      next: (posts: Post[]) => {
        this.posts = posts;
        console.log('Posts:', this.posts);
  
        // Log user details for each post
        this.posts.forEach((post) => {
          console.log('User details for Post', post.id, ':', post.user);
        });
  
        // Fetch comments for each post
        for (const post of this.posts) {
          if (post.id) {
            this.postCommentService.getCommentById(post.id.toString()).subscribe((comments) => {
              // Make sure comments is an array
              post.comments = Array.isArray(comments) ? comments : [comments];
  
              // Load user details for comments
              for (const comment of post.comments) {
                this.userService.getUserAttributesById(comment.userId).subscribe((user) => {
                  comment.user = user;
                });
              }
            });
          }
        }
  
        // Load user details for comments
        this.loadUserDetailsForComments();
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
  
  

  hideAddPostModal() {
    this.displayAddPostModal = false;
  }

  loadUserDetailsForPosts(): void {
    for (const post of this.posts) {
      this.userService.getUserAttributesById(post.userId).subscribe((user) => {
        post.user = user;
      });
    }
  }

  loadUserDetailsForComments(): void {
    for (const post of this.posts) {
      if(post.comments){
        for (const comment of post.comments) {
          this.userService.getUserAttributesById(comment.userId).subscribe((user) => {
            comment.user = user;
          });
        }
      }
    }
  }
  
  

  deletePost(postId: string): void {
    if (
      this.userDetails.email === 'admin@admin.com' ||
      this.posts.find((post) => post.id === postId)?.userId === this.userDetails.userId
    ) {
      this.postService.deletePost(postId).subscribe(
        () => {
          console.log('Post deleted successfully');
          this.refreshHomePage();
          this.hideDeleteDialog();
        },
        (error: any) => {
          console.error('Failed to delete post: ', error);
          this.hideDeleteDialog();
        }
      );
    } else {
      console.log('User is not authorized to delete this post.');
      this.hideDeleteDialog();
    }
  }

  showDeleteDialog(post: Post) {
    this.displayConfirmationDialog = true;
    if (post.id) {
      this.postIdToDelete = post.id;
    }
  }

  hideDeleteDialog() {
    this.displayConfirmationDialog = false;
  }

  addComment(postId: string | undefined) {
    if (postId) {
      if (this.addCommentForm.valid) {
        this.authService.getUserId().subscribe((userId: string | null) => {
          if (userId) {
            const newComment: PostComments = {
              content: this.addCommentForm.controls.content.value!,
              userId: userId,
              user: this.user,
              postId: postId
            };
            this.postCommentService.createComment(newComment).subscribe(
              () => {
                console.log('Comment added successfully');
                this.refreshHomePage();
              },
              (error: any) => {
                console.error('Failed to add post: ', error);
              }
            );
            this.addCommentForm.reset();
          }
        });
      }
    }
  }  

  isCommentOwner(comment: PostComments | undefined): boolean {
    return this.userDetails && comment?.userId === this.userDetails.userId;
  }

  isPostOwner(post: Post | undefined): boolean {
    return this.userDetails && post?.userId === this.userDetails.userId;
  }

  isAdmin(): boolean {
    return this.userDetails && this.userDetails.email === 'admin@admin.com';
  }

  deleteComment(postId: string, commentId: string) {
    if (
      this.isAdmin() ||
      this.isPostOwner(this.posts.find((post) => post.id === postId)) ||
      this.isCommentOwner(
        this.posts
          .find((post) => post.id === postId)
          ?.comments?.find((comment) => comment.id === commentId)
      )
    ) {
      this.postCommentService.deleteComment(commentId).subscribe(
        () => {
          console.log('Comment deleted successfully');
          this.refreshHomePage();
          this.hideDeleteDialog();
        },
        (error: any) => {
          console.error('Failed to delete comment: ', error);
          this.hideDeleteDialog();
        }
      );
    } else {
      console.log('User is not authorized to delete this comment.');
      this.hideDeleteDialog();
    }
  }
  
}
