# Build and Publish on Heroku

On git bash
    1. heroku login
    2. heroku container:login
    3. docker build -t name-of-image .
    4. heroku container:push web -a mars-promotion-api
    5. heroku container:release web -a mars-promotion-api