// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Load list of registered users on page load
    loadUsers();

    // Handle register form submission
    $('#registerForm').submit(function (event) {
        event.preventDefault();
        var formData = {
            username: $('#username').val(),
            // Add other form fields
        };
        $.post('/api/freelancer', formData, function () {
            alert('User registered successfully');
            loadUsers();
        });
    });

    // Handle update form submission
    $('#updateForm').submit(function (event) {
        event.preventDefault();
        var userId = $('#userId').val();
        var formData = {
            // Add form fields for attributes to update
        };
        $.ajax({
            url: '/api/freelancer/' + userId,
            type: 'PUT',
            data: formData,
            success: function () {
                alert('User details updated successfully');
                loadUsers();
            }
        });
    });

    // Handle delete form submission
    $('#deleteForm').submit(function (event) {
        event.preventDefault();
        var userId = $('#deleteUserId').val();
        $.ajax({
            url: '/api/freelancer/' + userId,
            type: 'DELETE',
            success: function () {
                alert('User deleted successfully');
                loadUsers();
            }
        });
    });

    // Function to load list of registered users
    function loadUsers() {
        $.get('/api/freelancer', function (data) {
            $('#userList').empty();
            data.forEach(function (user) {
                $('#userList').append('<li>' + user.username + '</li>');
            });
        });
    }
});