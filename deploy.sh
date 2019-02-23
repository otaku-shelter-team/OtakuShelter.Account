echo "cd /root/OtakuShelter.Infrastructure/src && \
ansible-playbook deploy.yml \
-e \"\
otakushelter_hosts=accounts \
otakushelter_container=otakushelter_account \
otakushelter_image=otakushelter/account \
otakushelter_port=4002 \
otakushelter_build_number=$TRAVIS_BUILD_NUMBER \
otakushelter_database_password=$OTAKUSHELTER_DATABASE_PASSWORD \
otakushelter_secret=$OTAKUSHELTER_SECRET\" \
-i inventories/staging"