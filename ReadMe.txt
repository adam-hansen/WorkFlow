
//Command to launch a local container registry (repo)
docker run -d -p 5000:5000 --restart=always --name registry registry:2

//Command to execute docker file and generate build
docker build -t graphql .

//command to tag imagine for container repo
docker tag graphql localhost:5000/graphql

//command to push image to container repo
docker push localhost:5000/graphql

//Commands to run kubernetes deploy files
//must be ran from within their repsective folder
kubectl apply -f deployment.yaml